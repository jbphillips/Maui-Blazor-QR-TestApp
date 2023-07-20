# QR Reader for MAUI + Blazor Demo

## Project Life Purpose:
MAUI and Blazor hybrid demo shows a working relationship between a MAUI component and Blazor
Using Zxing although not .NET 8.0 ready

## Design Goals:
- CameraBarcodeReaderView is created at runtime when needed to read a QR code
- Dependency injection to communicate between MAUI and Blazor parts
- Capture: 
	- Reader is a MAUI component, is not a Blazor (html) element

## Whats in this Solution
- Zxing is not .NET 8.0 ready
- Another capture oiption may be required
- Zxing.Net.Maui
- Zxing libraries - updating them manually to .NET 7.0 and 8.0 for trial
- Blazor MAUI Hybrid .NET 7.0
- QR service

