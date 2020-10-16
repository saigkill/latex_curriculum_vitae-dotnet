# Latex Curriculum Vitae

<img src="https://raw.githubusercontent.com/saigkill/latex_curriculum_vitae-dotnet/master/latex_curriculum_vitae/Assets/images/default.png" align="center" alt="logo" width="500"/>

## DESCRIPTION

Latex Curriculum Vitae is a simple solution for writing job applications with producing beautiful documents with LaTEX.
You can write, compile and send the stuff directly within the app. Also you get a simple CSV file, what contains all sent stuff. You can use it as example in a Excel-Sheet.

The CHANGELOG.md contains a detailed description of what has changed.

Latex Curriculum Vitae is released under the GPL3 License, see the file 'LICENSE.md' for more information.

The official website is:

    https://github.com/saigkill/latex_curriculum_vitae-dotnet

|What|Where|
|-----|-------------------------------------------------------------------------------------|
|code  | [https://github.com/saigkill/latex_curriculum_vitae-dotnet] |
|docs | [https://saigkill.github.io/latex_curriculum_vitae-dotnet/] |
|bugs & feature requests  | [https://github.com/saigkill/latex_curriculum_vitae-dotnet/issues] |
|openhub statistics | [https://www.openhub.net/p/latex_curriculum_vitae-dotnet] |
|authors blog | [http://saschamanns.de] |

| What | Status |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|code quality | [![Maintainability](https://api.codeclimate.com/v1/badges/976914ee0f04dbd277c2/maintainability)](https://codeclimate.com/github/saigkill/latex_curriculum_vitae-dotnet/maintainability) |
|continuous integration | tbf |
|dependencies|[![Dependabot Status](https://api.dependabot.com/badges/status?host=github&repo=saigkill/latex_curriculum_vitae-dotnet)](https://dependabot.com) |

## SCREENSHOT

### Main

[![Screenshot](https://raw.githubusercontent.com/saigkill/publican_creators/master/docs/PublicanCreators.png)](https://github.com/saigkill/publican_creators)

### Revision Creator

[![Screenshot](https://raw.githubusercontent.com/saigkill/publican_creators/master/docs/RevisionCreator.png)](https://github.com/saigkill/publican_creators)

## FEATURES/PROBLEMS

* GUI to control publican

## SYNOPSIS

    $ publican_creators.rb (Main program)
    $ revision_creator.rb (The revision updater)

    Or just use the Launcher.

This Gem was programmed and tested on Linux systems. If anyone would like to make the methods also fit for other OS, 
I'm happy about Pull requests.

## REQUIREMENTS

* nokogiri
* parseconfig
* rainbow
* notifier

## REQUIREMENTS (hard dependencies)

* yad
* publican (a 4.x version is needed)

## INSTALL

The installation is very easy.

    gem install publican_creators
    cd /path/to/gem (In case of using RVM ~/.rvm/gems/ruby-$RUBYVERSION/gems/publican_creators)
    rake

You have to run the setup after each gem update.

## DEVELOPERS

After checking out the source, run:

 `$ rake newb`
This task will install any missing dependencies, run the tests/specs, 
and generate the RDoc.
