# Sleepytime

A simple program to lock your workstation and put all monitors into powersave
mode.

## Download

You can download the compiled executable [here][downloadLink].

## Doesn't [NirCmd][] do this?

Yes, with a very simple script:

```
lockws
monitor off
```

## So why write something new?

Because NirCmd hangs after putting my monitor to sleep, leaving an army of
zombie processes over time. This annoys me more than it should.

## What causes that?

Interestingly enough, the Windows SendMessage API is not returning on my system
when called with `HWND_BROADCAST` or `HWND_TOPMOST` and the monitor power
command. So, really, it is probably not NirCmd's fault.

## The "fix"

Rather than figure out which program/driver/whatever is causing that problem, I
just decided to write my own that doesn't broadcast the monitor off message to
_everyone_. Instead, I create a dummy form, and send the message to that.

Windows intercepts the message and does its thing, and we're golden!

[NirCmd]:       http://www.nirsoft.net/utils/nircmd.html
[downloadLink]: https://drive.google.com/open?id=0B3hK6MOhVmfAdkJhdkhIX01pUDQ&authuser=0
