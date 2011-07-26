﻿namespace FSharp.Core.CS

open System
open System.Runtime.CompilerServices

[<Extension>]
type ListExtensions =
    [<Extension>]
    static member Match (l, empty: Func<_>, nonempty: Func<_,_,_>) =
        match l with
        | [] -> empty.Invoke()
        | x::xs -> nonempty.Invoke(x,xs)

    [<Extension>]
    static member Choose (l, chooser: Func<_,_>) =
        List.choose chooser.Invoke l

    [<Extension>]
    static member Cons (l, e) = e::l
        
type FSharpList =
    static member New([<ParamArray>] values: 'a array) =
        Seq.toList values

    static member Cons(a, l) = a::l