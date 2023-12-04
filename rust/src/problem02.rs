pub fn solve_a(lines: &mut dyn Iterator<Item = String>) -> u32 {
    let mut sum = 0;

    while let Some(line) = lines.next() {
    }

    sum
}

#[test]
fn solve_a_should_return_8_with_sample_data() {
    let mut lines = crate::utils::str_to_iter(indoc::indoc!("
        Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
        Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
        Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
        Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
        Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
    "));

    let actual = solve_a(&mut lines);

    assert_eq!(8, actual);
}

pub fn solve_b(lines: &mut dyn Iterator<Item = String>) -> u32 {
    let mut sum = 0;

    while let Some(line) = lines.next() {
    }

    sum
}

#[test]
fn solve_b_should_return_2286_with_sample_data() {
    let mut lines = crate::utils::str_to_iter(indoc::indoc!("
        Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
        Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
        Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
        Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
        Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
    "));

    let actual = solve_b(&mut lines);

    assert_eq!(2286, actual);
}