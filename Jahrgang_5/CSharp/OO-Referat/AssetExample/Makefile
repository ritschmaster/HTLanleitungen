########################################################################
# Copyright (C) 2015 Richard Bäck <richard.baeck@openmailbox.org>
#
# This file is part of AssetExample.
#
# AssetExample is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# AssetExample is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
#
# You should have received a copy of the GNU General Public License
# along with AssetExample.  If not, see <http://www.gnu.org/licenses/>.
########################################################################

SOURCE_FILES := Asset.java Main.java
CLASS_FILES := $(wildcard *.class)
MAIN_CLASS := Main

all:
	javac $(SOURCE_FILES)

clean:
	rm $(CLASS_FILES)

run:
	java $(MAIN_CLASS)
