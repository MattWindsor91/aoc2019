#lang typed/racket

; Common utility definitions for AoC2019 solutions.

(provide
 string->int
 open-file-of-ints)

; Reads a string as an integer.
;
; Returns 0 if the string is not a well-formed integer, as we're assuming that
; the input file is always well-formed.
(define (string->int [str : String]) : Integer
  (let ([attempt (string->number str)])
    (if (exact-integer? attempt) attempt 0)))

; Opens the given file and reads a list of integers (one per line) from it.
(define (open-file-of-ints [file : Path]) : (Listof Integer)
  (map string->int (port->lines (open-input-file file))))
