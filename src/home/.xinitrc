exec /usr/bin/i3
#feh --bg-max --randomize ~/.wallpaper/* &
#exec feh --bg-max ~/background_fill.png &
#exec xloadimage -onroot -brighten 250 -center ~/background_fill.png &
#exec xrandr --output VGA1 --auto --left-of eDP1 &
# NOTE start wit a better screen monitor
exec xrandr --output VGA-1 --gamma .8:.8:.8 &
exec xrandr --output eDP-1 --gamma .9:.9:.9 &
exec xrandr --output VGA-1 --left-of eDP-1 &                                                                                                                     
exec xrandr --output VGA-1 --mode 1440x900 &
     
