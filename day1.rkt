#lang typed/racket

(require "aoc2019.rkt")

; Calculates the fuel of the given amount of mass.
(define (fuel-of-mass [mass : Integer]) : Integer
  (max 0 (- (exact-floor (/ mass 3)) 2)))

; Calculates one step in the recursive fuel of mass calculation.
(define (recursive-fuel-of-mass-step [sum : Integer] [mass : Integer]) : Integer
  (if (<= mass 0)
      sum
      (let ([fuel (fuel-of-mass mass)])
        (recursive-fuel-of-mass-step (+ sum fuel) fuel))))

; Calculates the fuel of the given amount of mass, then adds the fuel of the
; mass of that fuel, and so on until the amount of added mass is 0.
(define (recursive-fuel-of-mass [mass : Integer]) : Integer
  (recursive-fuel-of-mass-step 0 mass))

; Adds one mass amount's part1 and part2 fuel calculations to a pair of tallies.
(define (calc-fuels-step [mass : Integer] [result : (Pairof Integer Integer)]) : (Pairof Integer Integer)
  (cons (+ (fuel-of-mass mass) (car result))
        (+ (recursive-fuel-of-mass mass) (cdr result))))

; Calculates the part1 and part2 fuel amounts for a list of masses.
(define (calc-fuels [masses : (Listof Integer)]) : (Pairof Integer Integer)
  (foldl calc-fuels-step (cons 0 0) masses))

; Runs the part1 and part2 calculations for the named file.
(define (run [file : Path]) : (Pairof Integer Integer)
  (calc-fuels (open-file-of-ints file)))

; The output on the REPL will be '(x . y), where x is the part1 result and
; y is the part2 result.
(run (string->path "day1.txt"))
