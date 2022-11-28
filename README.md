# OTP Translator

CLI and library for translating OTP (One-time-password) archives between different OTP apps. 

## Supported OTP apps

| App                                                   | Notes                                                                          |
|-------------------------------------------------------|--------------------------------------------------------------------------------|
| [Aegis](https://github.com/beemdevelopment/Aegis)     | Supports translating the unencrypted json file.                                |
| [Raivo](https://github.com/raivo-otp/ios-application) | Supports translating the encrypted json file inside the encrypted ZIP archive. |

## Icons?

Currently, icons are not included in the archive translation. Each app uses a unique approach, so we'll have to noodle on this one for a while.

## Usage

First, build the solution in Visual Studio or JetBrains Rider.

| Objective       | Command                                                 |
|-----------------|---------------------------------------------------------|
| Aegis --> Raivo | `./otpt -f aegis -t raivo -s ./plain-aegis-export.json` |
| Raivo --> Aegis | `./otpt -f raivo -t aegis -s ./plain-raivo-export.json` |

## Encryption notes

Make sure you handle those unencrypted archives properly. Eventually, it would be good to support encrypted archives, to avoid exposing plain text TOTP codes on the transport medium.
