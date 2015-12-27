module Customer

type Customer =
    {
        Name : string
        Phone : string
        Email : string
        Address : Address
    }
and Address =
    {
        Street : string
        Suburb : string
        City : string
        ZipCode : string
        Planet : string
    }