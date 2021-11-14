// See https://aka.ms/new-console-template for more information
using MigratePM6;
using System.Diagnostics;

Console.WriteLine("Migrating data...");

Stopwatch sw = new Stopwatch();
sw.Start();

//int noOfOperations= 4;
//int cids = 400_000;

//int counter = 0;

var localContext = new dbContext("Host=localhost;Database=db;Username=patrik;Password=secretpw;Port=5555");

var remoteConext = new dbContext("Host=65.108.61.134;Database=MQS;Username=patrik;Password=secretpw;Port=30378");
var remoteConext1 = new dbContext("Host=65.108.61.134;Database=MQS;Username=patrik;Password=secretpw;Port=30378");
var remoteConext2 = new dbContext("Host=65.108.61.134;Database=MQS;Username=patrik;Password=secretpw;Port=30378");
var remoteConext3 = new dbContext("Host=65.108.61.134;Database=MQS;Username=patrik;Password=secretpw;Port=30378");

Calculation action = new Calculation();
Calculation action1 = new Calculation();
Calculation action2 = new Calculation();
Calculation action3 = new Calculation();

//List<dbContext> contexts = new List<dbContext>();

//for (int i = 0; i < noOfOperations; i++)
//{
//    contexts.Add(new dbContext("Host=65.108.61.134;Database=MQS;Username=patrik;Password=secretpw;Port=30378"));
//}



var query = from rec in localContext.Pm6optChon300nosalts
            where rec.Cid <= 100_000
            select rec;

var query1 = from rec in localContext.Pm6optChon300nosalts
             where rec.Cid > 100_000 && rec.Cid <= 200_000
             select rec;

var query2 = from rec in localContext.Pm6optChon300nosalts
             where rec.Cid > 200_000 && rec.Cid <= 300_000
             select rec;

var query3 = from rec in localContext.Pm6optChon300nosalts
             where rec.Cid > 300_000 && rec.Cid <= 400_000
             select rec;



List<Pm6optChon300nosalt> records = query.ToList();
List<Pm6optChon300nosalt> records1 = query1.ToList();
List<Pm6optChon300nosalt> records2 = query2.ToList();
List<Pm6optChon300nosalt> records3 = query3.ToList();

await Task.WhenAll(new[]
    {
        action.WriteToExternal(remoteConext, records),
        action1.WriteToExternal(remoteConext, records1),
        action2.WriteToExternal(remoteConext, records2),
        action3.WriteToExternal(remoteConext, records3),

    });

await remoteConext.SaveChangesAsync();
await remoteConext1.SaveChangesAsync();
await remoteConext2.SaveChangesAsync();
await remoteConext3.SaveChangesAsync();

sw.Stop();
Console.WriteLine($"{sw.Elapsed} time elapsed");
//Console.WriteLine($"{records.Count + records1.Count + records2.Count + records3.Count} records were migrated");
Console.WriteLine($"{records.Count} records were migrated");

