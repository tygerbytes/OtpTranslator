using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OtpTranslator.Lib;
using OtpTranslator.Lib.Model.Aegis;
using OtpTranslator.Lib.Translations.Aegis;
using OtpTranslator.Lib.Translations.Raivo;

namespace OtpTranslator.CLI
{
    [ValidateRequiredParameters]
    [Command(Name = "otpt", Description = "OTP Translator")]
    internal class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var app = new CommandLineApplication<Program>();
            app.Conventions.UseDefaultConventions(); 
            
            var returnCode = await app.ExecuteAsync(args);
            return returnCode;
        }
        
        [Option(Description = "Type to convert from", ShortName = "f")]
        public string FromType { get; }
        
        [Option(Description = "Type to convert to", ShortName = "t")]
        public string ToType { get; }
        
        [Option(Description = "Path to source file", ShortName = "s")]
        public string SourcePath { get; }

        public async Task<int> RunAsync(CommandLineApplication app, CancellationToken cancellationToken = default)
        {
            var from = OtpClientEnum.Parse(FromType);
            var to = OtpClientEnum.Parse(ToType);

            var translator = new OtpFileTranslator();
            await translator.TranslateAsync(from, to, SourcePath);
            
            Console.WriteLine("🏁Done!");

            return 0;
        }

        /// <summary>
        /// Called by CommandLineApplication
        /// </summary>
        /// <param name="app"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<int> OnExecuteAsync(CommandLineApplication app, CancellationToken cancellationToken = default)
        {
            return await RunAsync(app, cancellationToken);
        }
    }
}