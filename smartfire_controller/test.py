#!/usr/bin/python
from fireplace import Fireplace

serial = 0x847902
ecc1_C = 0x1
ecc1_D = 0x5
ecc2_C = 0x8
ecc2_D = 0x2

fp = Fireplace(serial,ecc1_C,ecc1_D,ecc2_C,ecc2_D)
fp.set(power=False)
#fp.set(pilot=0,light=6,thermostat=0,power=1,front=6,fan=6,aux=0,flame=6)

#fp = Fireplace()
#fp = Fireplace(serial=['100001001','011110010','000000100'])
