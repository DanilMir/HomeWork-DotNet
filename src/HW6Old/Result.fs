module HW6.Result

type Result<'T> =
    | Success of 'T
    | Fail of message: string
