mod problem01;
mod problem02;
mod utils;

use std::env::{args};
use indoc::indoc;
use crate::utils::{stdin_lines};

fn main() {
    if let Some(problem) = args().nth(1) {
        if solve(problem.as_str()) {
            return;
        }
    }

    help();
}

fn solve(problem: &str) -> bool {
    match problem {
        "1a" => {
            println!("{}", problem01::solve_a(&mut stdin_lines()));
        },
        "1b" => {
            println!("{}", problem01::solve_b(&mut stdin_lines()));
        },
        "2a" => {
            println!("{}", problem02::solve_a(&mut stdin_lines()));
        },
        "2b" => {
            println!("{}", problem02::solve_b(&mut stdin_lines()));
        },
        _ => {
            return false;
        }
    }

    true
}

fn help() {
    println!(indoc!("
        Advent of Code 2023 (https://adventofcode.com)
        Run: adventofcode2023 problem
            problem is one of 1a, 2a
                              1b, 2b
    
        The utility reads input from stdin and prints result to stdout."));
}