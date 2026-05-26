using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaultEye.Models;

namespace VaultEye.Scanner.services
{
    public class FileScannerService
    {
        private readonly HashSet<string> AllowedExtensions =
            new(StringComparer.OrdinalIgnoreCase)
            {
                // C# / .NET
                ".cs",
                ".csproj",
                ".sln",
                ".vb",
                ".fs",
                ".config",
                ".props",
                ".targets",

                // JavaScript / TypeScript
                ".js",
                ".jsx",
                ".ts",
                ".tsx",
                ".mjs",
                ".cjs",

                // Front-end / Web
                ".html",
                ".htm",
                ".css",
                ".scss",
                ".sass",
                ".less",
                ".vue",
                ".astro",
                ".svelte",

                // Node / Package Managers
                ".npmrc",
                ".yarnrc",

                // Python
                ".py",
                ".pyw",
                ".ipynb",

                // Java / Kotlin / JVM
                ".java",
                ".kt",
                ".kts",
                ".gradle",

                // Go
                ".go",

                // Rust
                ".rs",
                ".toml",

                // Ruby
                ".rb",
                ".erb",
                ".gemspec",

                // PHP
                ".php",
                ".phtml",

                // C / C++
                ".c",
                ".h",
                ".cpp",
                ".hpp",
                ".cc",
                ".hh",

                // Swift / iOS
                ".swift",

                // Objective-C
                ".m",
                ".mm",

                // Shell / Linux
                ".sh",
                ".bash",
                ".zsh",

                // PowerShell
                ".ps1",
                ".psm1",

                // Lua
                ".lua",

                // Perl
                ".pl",
                ".pm",

                // R
                ".r",

                // Dart / Flutter
                ".dart",

                // Scala
                ".scala",

                // Elixir
                ".ex",
                ".exs",

                // Clojure
                ".clj",

                // Haskell
                ".hs",

                // SQL
                ".sql",

                // Templates
                ".hbs",
                ".ejs",
                ".twig",

                // Config / Infra
                ".json",
                ".jsonc",
                ".yaml",
                ".yml",
                ".xml",
                ".toml",
                ".ini",
                ".cfg",
                ".conf",

                // Secrets / Env
                ".env",
                ".env.local",
                ".env.dev",
                ".env.development",
                ".env.prod",
                ".env.production",

                // Docker / Containers
                ".dockerfile",

                // Kubernetes
                ".helm",

                // Terraform
                ".tf",
                ".tfvars",

                // GitHub / CI-CD
                ".github",
                ".gitlab-ci",

                // Certificates / Keys
                ".pem",
                ".key",
                ".crt",
                ".pfx",
                ".asc",

                // Markdown / Docs
                ".md",
                ".rst",

                // Generic text
                ".txt",

                // Logs
                ".log"
            };
     
        private readonly HashSet<string> IgnoredDirectories =
            new(StringComparer.OrdinalIgnoreCase)
            {
                // .NET
                "bin",
                "obj",

                // Node.js
                "node_modules",
                ".npm",
                ".pnpm-store",
                ".yarn",

                // Git
                ".git",

                // Front-end build
                "dist",
                "build",
                ".next",
                ".nuxt",
                ".svelte-kit",
                ".angular",
                ".astro",

                // Coverage / Reports
                "coverage",
                ".coverage",
                "TestResults",

                // Python
                "__pycache__",
                ".pytest_cache",
                ".mypy_cache",
                ".tox",
                ".venv",
                "venv",
                "env",

                // Java / Kotlin
                ".gradle",
                ".idea",
                "out",

                // VS / IDE
                ".vs",
                ".vscode",
                ".idea",

                // Docker
                ".docker",

                // Terraform
                ".terraform",

                // Ruby
                ".bundle",
                "vendor",

                // Rust
                "target",

                // Go
                "vendor",

                // Cache
                ".cache",
                ".temp",
                "tmp",
                "temp",

                // Logs
                "logs",

                // CI/CD
                ".github",
                ".gitlab",

                // OS generated
                ".DS_Store",
                "Thumbs.db"
            };

        public IEnumerable<ScannedFile> ReadFiles(string directory)
        {   
            Console.WriteLine("[#] Scan started . . .");

            if(!Directory.Exists(directory))
            {
                Console.WriteLine($"[!] Directory {directory} not found!");
                return Enumerable.Empty<ScannedFile>();
            }

            List<ScannedFile> scannedFiles = new();

            ScanDirectory(directory, scannedFiles);

            return scannedFiles;
        }

        private void ScanDirectory(string directory, List<ScannedFile> scannedFiles)
        {
            if(IgnoredDirectories.Any(ignored => directory.Contains(ignored, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            string[] files = Directory.GetFiles(directory);

            foreach(var file in files)
            {
                string extension = Path.GetExtension(file);

                if (!AllowedExtensions.Contains(extension))
                {
                    continue;
                }

                try
                {
                    ScannedFile scFile = new()
                    {
                        FileName = file,
                        Content = File.ReadLines(file).ToList()
                    };

                    scannedFiles.Add(scFile);
                }
                catch {}
            }

            string[] directories = Directory.GetDirectories(directory);

            foreach(var subDirectory in directories)
            {
                ScanDirectory(subDirectory, scannedFiles);
            }
        }
    }
}