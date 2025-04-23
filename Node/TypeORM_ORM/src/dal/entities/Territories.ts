import {
  Column,
  Entity,
  Index,
  JoinColumn,
  ManyToMany,
  ManyToOne,
} from "typeorm";
import { Employees } from "./Employees";
import { Region } from "./Region";

@Index("PK_Territories", ["territoryId"], { unique: true })
@Entity("Territories", { schema: "dbo" })
export class Territories {
  @Column("nvarchar", { primary: true, name: "TerritoryID", length: 20 })
  territoryId: string;

  @Column("nchar", { name: "TerritoryDescription", length: 50 })
  territoryDescription: string;

  @ManyToMany(() => Employees, (employees) => employees.territories)
  employees: Employees[];

  @ManyToOne(() => Region, (region) => region.territories)
  @JoinColumn([{ name: "RegionID", referencedColumnName: "regionId" }])
  region: Region;
}
