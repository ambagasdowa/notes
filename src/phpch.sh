#!/bin/bash


#change to 7.2
sudo a2dismod php7.2 ; sudo a2enmod php5.6 ; sudo systemctl restart apache2 ; sudo update-alternatives --set php /usr/bin/php7.2

#change to 5.6
sudo a2dismod php5.6 ; sudo a2enmod php7.2 ; sudo systemctl restart apache2 ; sudo update-alternatives --set php /usr/bin/php5.6





