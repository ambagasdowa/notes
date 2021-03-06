#!/bin/bash
#####################################################################################################
# Root password needed for some operations
#####################################################################################################
# CURRENT_USER=`whoami`
# echo -n "Enter the password for $CURRENT_USER: "
# stty_orig=`stty -g` # save original terminal setting.
# stty -echo          # turn-off echoing.
# read passwd         # read the password
# stty $stty_orig     # restore terminal setting.
passwd='pekas'
#####################################################################################################
# Install dependencies
#####################################################################################################

# Stop unconfigured services

# echo "$passwd" | sudo -S service lighttpd stop
# echo "$passwd" | sudo -S service mpd stop
#echo "$passwd" | sudo -S service nginx stop
#echo "$passwd" | sudo -S service apache2 stop
#echo "$passwd" | sudo -S service apache2 start
echo "$passwd" | sudo -S service network-manager stop
# printf "nameserver 8.8.8.8 \nnameserver 8.8.4.4 \n" | sudo tee -a /etc/resolv.conf


# echo "$passwd" | sudo -S service virtuoso-opensource-6.1 stop
# echo "$passwd" | sudo -S service libvirtd stop
# echo "$passwd" | sudo -S service libvirt-guests stop
# echo "$passwd" | sudo -S service spice-vdagent stop
# echo "$passwd" | sudo -S service virtlogd stop
# echo "$passwd" | sudo -S service zfs-fuse stop


# NOTE start wit a better screen monitor
xrandr --output HDMI2 --gamma .8:.8:.8
xrandr --output eDP1 --gamma .9:.9:.9
xrandr --output HDMI2 --left-of eDP1
xrandr --output HDMI2 --mode 1440x900

#mounting the resources
mount /media/devops
echo "$passwd" | sudo sshfs ambagasdowa@192.168.20.215:/home/ambagasdowa/ /media/cloud/ -o allow_other -o Ciphers=arcfour -o Compression=no
#mount /media/externalx
#mount /media/externaly
