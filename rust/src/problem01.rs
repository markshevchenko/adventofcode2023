use phf::{Map, phf_map};

pub fn solve_a(lines: &mut dyn Iterator<Item = String>) -> u32 {
    let mut sum = 0;

    while let Some(line) = lines.next() {
        let first_digit =
            line.chars()
                .find(|c| c.is_ascii_digit())
                .unwrap()
                .to_digit(10)
                .unwrap();
        let last_digit =
            line.chars()
                .rfind(|c| c.is_ascii_digit())
                .unwrap()
                .to_digit(10)
                .unwrap();

        sum += 10 * first_digit + last_digit;
    }

    sum
}

#[test]
fn solve_a_should_return_142_with_sample_data() {
    let mut lines = crate::utils::str_to_iter(indoc::indoc!("
        1abc2
        pqr3stu8vwx
        a1b2c3d4e5f
        treb7uchet"
    ));

    let actual = solve_a(&mut lines);

    assert_eq!(142, actual);
}

const DIGITS: &'static [&'static str] = &[
    "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
    "1", "2", "3", "4", "5", "6", "7", "8", "9"
];

static VALUES: Map<&'static str, u32> = phf_map! {
    "one" => 1, "two" => 2, "three" => 3, "four" => 4, "five" => 5,
    "six" => 6, "seven" => 7, "eight" => 8, "nine" => 9,
    "1" => 1, "2" => 2, "3" => 3, "4" => 4, "5" => 5,
    "6" => 6, "7" => 7, "8" => 8, "9" => 9
};

pub fn solve_b(lines: &mut dyn Iterator<Item = String>) -> u32 {
    let mut sum = 0;

    while let Some(line) = lines.next() {
        let first_digit =
            DIGITS
                .iter()
                .map(|digit| (line.find(digit), VALUES[digit]))
                .filter(|(index, _)| index.is_some())
                .min_by_key(|(index, _)| index.unwrap())
                .unwrap()
                .1;
        let last_digit =
            DIGITS
                .iter()
                .map(|digit| (line.rfind(digit), VALUES[digit]))
                .filter(|(index, _)| index.is_some())
                .max_by_key(|(index, _)| index.unwrap())
                .unwrap()
                .1;

        sum += 10 * first_digit + last_digit;
    }

    sum
}

#[test]
fn solve_b_should_return_281_with_sample_data() {
    let mut lines = crate::utils::str_to_iter(indoc::indoc!("
        two1nine
        eightwothree
        abcone2threexyz
        xtwone3four
        4nineeightseven2
        zoneight234
        7pqrstsixteen"
    ));

    let actual = solve_b(&mut lines);

    assert_eq!(281, actual);
}