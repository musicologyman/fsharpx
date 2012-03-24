﻿module FSharp.TypeProviders.Tests.XamlTests

open NUnit.Framework
open FSharpx
open FsUnit

type T = XAML< @"StackPanel.xaml">

[<Test>][<RequiresSTA>]
let ``Can access the grid``() =      
   let window = T()
   window.MainGrid.Name |> should equal "MainGrid"

[<Test>][<RequiresSTA>]
let ``Can access the stackpanel``() =      
   let window = T()
   window.StackPanel1.Name |> should equal "StackPanel1"

[<Test>][<RequiresSTA>]
let ``Can access the first button``() =      
   let window = T()
   window.Button1.Name |> should equal "Button1"

[<Test>][<RequiresSTA>]
let ``The window should have the right type``() =
   let window = T()
   window.Control.GetType() |> should equal typeof<System.Windows.Window>

[<Test>][<RequiresSTA>]
let ``The grid should have the right type``() =
   let window = T()
   window.MainGrid.GetType() |> should equal typeof<System.Windows.Controls.Grid>

[<Test>][<RequiresSTA>]
let ``The button should have the right type``() =
   let window = T()
   window.Button2.GetType() |> should equal typeof<System.Windows.Controls.Button>
