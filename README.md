# Sleepytime

A simple program to lock your workstation and put all monitors into powersave
mode.

## Doesn't NirCmd do this?

Yes, with a very simple nircmd script.

## So why write your own?

Because NirCmd hangs after putting my monitor to sleep, leaving an army of
zombie processes over time. This annoys me more than it should.

Plus, I just like writing C#, so why not? It's only a few lines of code.

## What causes that?

Interestingly enough, the Windows SendMessage API is not returning on my system
when called with `HWND_BROADCAST` or `HWND_TOPMOST` and the monitor power
command.

Rather than figure out which program/driver/whatever is causing that problem, I
just decided to write my own that doesn't broadcast the monitor off message to
_everyone_. Instead, I create a dummy form, and send the message to that.

Windows intercepts the message and does its thing, and we're golden!
