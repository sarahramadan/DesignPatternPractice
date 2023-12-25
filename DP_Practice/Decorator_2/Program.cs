// See https://aka.ms/new-console-template for more information
using Decorator;

Console.WriteLine("Hello, World!");

var cloudService = new CloudMailService();
cloudService.SendMail("first");

var onPremise = new OnPremiseMailServicer();
onPremise.SendMail("first");


var statistic = new StatisticMailService(cloudService);
statistic.SendMail("second");


var statistic2 = new StatisticMailService(onPremise);
statistic2.SendMail("second");


var db = new DatabaseMailService(cloudService);
db.SendMail("third");
foreach (var item in db.databases)
{
    Console.WriteLine("i = {0}", item);
}

var db2 = new DatabaseMailService(onPremise);
db2.SendMail("third");