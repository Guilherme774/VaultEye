# VaultEye

VaultEye is a lightweight AppSec and Secret Scanning tool built with C# and .NET.

The project focuses on detecting sensitive data, hardcoded credentials, secrets, tokens, and insecure patterns inside source code and files.

---

## Features

- Secret scanning
- Regex-based detection engine
- Modular architecture
- CLI interface
- Extensible rules engine
- Colored severity output
- AppSec-focused design

---

## Current Detection Capabilities

VaultEye can currently detect patterns such as:

- Hardcoded passwords
- Secrets
- Tokens
- API Keys

Example:

```env
password=123456
secret_key=my-secret
api_key=abc123
```

---

## Project Architecture

```txt
VaultEye
│
├── VaultEye.CLI
├── VaultEye.Core
├── VaultEye.Scanner
├── VaultEye.Rules
├── VaultEye.Reporting
└── VaultEye.Models
```

### Responsibilities

| Project | Responsibility |
|---|---|
| CLI | User input and terminal interaction |
| Core | Application orchestration |
| Scanner | File system scanning |
| Rules | Detection engine and security rules |
| Reporting | Output formatting |
| Models | Shared entities and contracts |

---

## Tech Stack

- C#
- .NET 8
- Regex Engine
- Console CLI

---

## Running the Project

### Clone repository

```bash
git clone <repository-url>
```

### Build project

```bash
dotnet build
```

### Run project

```bash
dotnet run --project ./src/VaultEye.CLI
```

---

## Example

```bash
Set the directory to scan >> ./samples/test.txt
```

Example output:

```txt
[HIGH] Sensitive Credential
File: ./samples/test.txt
Line: 12
Match: password=123456
```

---

## Roadmap

- [ ] Recursive directory scanning
- [ ] JWT analyzer
- [ ] AWS Key detection
- [ ] Entropy analysis
- [ ] JSON reporting
- [ ] SARIF reporting
- [ ] HTML reports
- [ ] GitHub Actions integration
- [ ] Multithread scanning
- [ ] CI/CD integration

---

## Goals

This project was created to:

- Study AppSec concepts
- Improve knowledge in secure development
- Practice software architecture
- Build security-focused tooling
- Explore SAST and Secret Scanning techniques

---

## Disclaimer

VaultEye is an educational and research-oriented project.

Use responsibly.

---

## License

MIT