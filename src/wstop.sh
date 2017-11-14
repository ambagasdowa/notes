#!/bin/bash


umount /media/devops/

mountpoint /media/devoops/ > /dev/null ;
devoops=${?}
if [[ "${devoops}" -eq 0 ]]; then
  echo "/media/devoops still mounted";
else
  echo "umount Successfull";
fi

umount /media/externalx/

mountpoint /media/externalx/ > /dev/null ;
externalx=${?}
if [[ "${externalx}" -eq 0 ]]; then
  echo "/media/externalx still mounted";
else
  echo "umount Successfull";
fi

umount /media/externaly/

mountpoint /media/externaly/ > /dev/null ;
externaly=${?}
if [[ "${externaly}" -eq 0 ]]; then
  echo "/media/externaly still mounted";
else
  echo "umount Successfull";
fi
