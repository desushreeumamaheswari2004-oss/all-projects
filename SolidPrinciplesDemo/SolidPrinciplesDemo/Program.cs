// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;

class Report
{
    public string Title = "Sales Report";
}

class ReportGenerator
{
    public Report Generate()
    {
        return new Report();
    }
}

class ReportSaver
{
    public void Save(Report report)
    {
        Console.WriteLine("Report Saved: " + report.Title);
    }
}

interface IFormatter
{
    string Format(Report report);
}

class PdfFormatter : IFormatter
{
    public string Format(Report report)
    {
        return "PDF Report: " + report.Title;
    }
}

class BaseReport
{
    public virtual string GetTypeName()
    {
        return "Base Report";
    }
}

class SalesReport : BaseReport
{
    public override string GetTypeName()
    {
        return "Sales Report";
    }
}

class ReportService
{
    private ReportGenerator _generator;
    private ReportSaver _saver;

    public ReportService(ReportGenerator generator, ReportSaver saver)
    {
        _generator = generator;
        _saver = saver;
    }

    public void Run()
    {
        var report = _generator.Generate();
        _saver.Save(report);
    }
}

class Logger
{
    private static Logger instance;
    private Logger() { }

    public static Logger Instance
    {
        get
        {
            if (instance == null)
                instance = new Logger();
            return instance;
        }
    }

    public void Log(string message)
    {
        Console.WriteLine("LOG: " + message);
    }
}

class Program
{
    static void Main()
    {
        Logger.Instance.Log("Application Started");

        var generator = new ReportGenerator();
        var saver = new ReportSaver();
        var service = new ReportService(generator, saver);
        service.Run();

        IFormatter formatter = new PdfFormatter();
        var report = new Report();
        Console.WriteLine(formatter.Format(report));

        BaseReport baseReport = new SalesReport();
        Console.WriteLine(baseReport.GetTypeName());

        Logger.Instance.Log("Application Finished");
    }
}