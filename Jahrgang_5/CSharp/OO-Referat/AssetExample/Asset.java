/************************************************************************
 * Copyright (C) 2015 Richard Bäck <richard.baeck@openmailbox.org>
 *
 * This file is part of AssetExample.
 *
 * AssetExample is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * AssetExample is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with AssetExample.  If not, see <http://www.gnu.org/licenses/>.
 ***********************************************************************/

public class Asset {
    private float acquisitionCosts;
    private String name;
    private float yearsOfService;

    public Asset(float acquisitionCosts, String name, float yearsOfService) {
        this.acquisitionCosts = acquisitionCosts;
        this.name = new String(name);
        this.yearsOfService = yearsOfService;
    }

    public Asset() {
        this(0, "", 0);
    }

    public float getDeprication() {
        return this.acquisitionCosts / this.yearsOfService;
    }

    public String getName() {
        return this.name;
    }

    public String getSaveName() {
        return new String(this.name);
    }
}
