#!/usr/bin/python
import sys
from fireplace import Fireplace

serial = 0x847902
ecc1_C = 0x1
ecc1_D = 0x5
ecc2_C = 0x8
ecc2_D = 0x2

if len(sys.argv) != 2:
    print("Usage: script.py <on|off>")
    sys.exit(1)

command = sys.argv[1].lower()

fp = Fireplace(serial,ecc1_C,ecc1_D,ecc2_C,ecc2_D)

if command == "on":
    fp.set(pilot=0, light=6, thermostat=0, power=1, front=6, fan=6, aux=0, flame=6)
elif command == "off":
    fp.set(power=False)
else:
    print("Invalid command. Use 'on' or 'off'.")
    sys.exit(1)
