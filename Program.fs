open Customer

[<EntryPoint>]
let main _ = 
    let signalr = SignalR.Server "http://localhost:7777"
    let staticServer = Static.Server "http://localhost:8777"

    let rec loop message =
        async {
            signalr.Send message
            do! Async.Sleep 1000
            return! loop message
        }

    {
        Name = "Someone I. Know"
        Phone = "555-123-4567"
        Email = "someone@somewhere.org"
        Address = 
            {
                Street = "123 Main Street"
                Suburb = "Midland"
                City = "Hometown"
                ZipCode = "12345"
                Planet = "Earth"
            }
    }
    |> loop
    |> Async.RunSynchronously