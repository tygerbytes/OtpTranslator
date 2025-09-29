# OTP Translator

CLI and library for translating OTP (One-time-password) archives between different OTP apps. 

## Supported OTP apps

| App                                                     | Notes                                                                                                        |
|---------------------------------------------------------|--------------------------------------------------------------------------------------------------------------|
| [Aegis](https://github.com/beemdevelopment/Aegis)       | Supports translating the unencrypted json file.                                                              |
| [2FAS](https://github.com/twofas)                       | Supports translating the unencrypted json file. 2FAS has its own importer tool, so you may not need this. :) |
| [Raivo𐃉](https://github.com/raivo-otp/ios-application) | Supports translating the encrypted json file inside the encrypted ZIP archive.                               |

𐃉**NOTE about Raivo**: I no longer use/recommend Raivo OTP. It seems they were bought out by some shady characters:

* [Raivo OTP has been acquired by Mobime](https://news.ycombinator.com/item?id=36942681)
* [Raivo OTP (2FA) resets data without warning](https://news.ycombinator.com/item?id=40843721)
* [Raivo OTP just deleted all tokens after update and is now asking for money](https://news.ycombinator.com/item?id=40523411)

## Icons?

Currently, icons are not included in the archive translation. Each app uses a unique approach, so we'll have to noodle on this one for a while.

## Usage

First, build the solution in Visual Studio or JetBrains Rider.

| Objective       | Command                                                  |
|-----------------|----------------------------------------------------------|
| Aegis --> Raivo | `./otpt -f aegis -t raivo -s ./plain-aegis-export.json`  |
| Raivo --> Aegis | `./otpt -f raivo -t aegis -s ./plain-raivo-export.json`  |
| Raivo --> 2FAS  | `./otpt -f raivo -t twofas -s ./plain-raivo-export.json` |

## Encryption notes

Make sure you handle those unencrypted archives properly. Eventually, it would be good to support encrypted archives, to avoid exposing plain text TOTP codes on the transport medium.
