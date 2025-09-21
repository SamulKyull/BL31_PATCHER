# BL31 PATCHER

This tool is designed to work with the Tina SDK. It patches the `bl31.bin` file to configure the Linux kernel to run in EL2 (Exception Level 2) mode instead of the default EL1 mode.

## Features

- Patches the `bl31.bin` file to configure the Linux kernel for EL2 mode.
- Compatible with Tina SDK and ARM-based platforms.

## How
We just patch `SPSR64` from `0x3c5` to `0x3c9`

<img width="691" height="187" alt="image" src="https://github.com/user-attachments/assets/b6aac22f-ff4b-4aec-aae0-3b3c0c4cd65f" />
```
SPSR_64(MODE_EL1, MODE_SP_ELX, DISABLE_ALL_EXCEPTIONS) = 0x3c5
SPSR_64(MODE_EL2, MODE_SP_ELX, DISABLE_ALL_EXCEPTIONS) = 0x3c9
```
