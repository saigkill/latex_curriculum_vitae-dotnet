#!/bin/bash
daps -m xml/MAIN-latex_curriculum_vitae.xml --styleroot=xslt/ html
rm -r ../docs/doc/*.html
cp -a build/MAIN-latex_curriculum_vitae/html/MAIN-latex_curriculum_vitae/* ../docs/doc
