namespace Homework4

module Calculator =
    let Calculate val1 operation val2 =
        match operation with
        | "+" -> val1 + val2
        | "-" -> val1 - val2
        | "*" -> val1 * val2
        | "/" -> val1 / val2
        | _ -> 0