#!/bin/bash
daps -m xml/MAIN-latex_curriculum_vitae.xml --styleroot=xslt/ html
rm -rf ../docs/*
cp -a build/MAIN-latex_curriculum_vitae/html/MAIN-latex_curriculum_vitae/* ../docs/