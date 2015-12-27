module SignalR

open Owin
open FSharp.Interop.Dynamic
open Microsoft.AspNet.SignalR
open Microsoft.Owin.Hosting
open Microsoft.Owin.Cors
open Microsoft.AspNet.SignalR.Hubs

[<HubName("myFirstHub")>]
type MyFirstHub () =
    inherit Hub ()

    member x.MessageToTheServer message =
        printfn "Soneone sent me a message! - %s" message


type Server (host: string) = 
    let startup (a:IAppBuilder) = 
        a.UseCors(CorsOptions.AllowAll) |> ignore
        a.MapSignalR() |> ignore

    let clients = GlobalHost.ConnectionManager.GetHubContext<MyFirstHub>().Clients

    do
        WebApp.Start(host, startup) |> ignore
        printfn "SignalR server running on %s" host

    member x.Send message = clients.All?messageToTheClient message
    

