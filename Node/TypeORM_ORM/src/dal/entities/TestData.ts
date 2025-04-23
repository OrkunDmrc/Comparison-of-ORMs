import { Column, Entity, Index, PrimaryGeneratedColumn } from "typeorm";

@Index("PK__TestData__8CC3310000C56314", ["id"], { unique: true })
@Entity("TestData", { schema: "dbo" })
export class TestData {
  @PrimaryGeneratedColumn({ type: "int", name: "Id" })
  id: number;

  @Column("varchar", { name: "TestName", nullable: true, length: 50 })
  testName: string | null;

  @Column("varchar", { name: "CpuUsage", nullable: true, length: 50 })
  cpuUsage: string | null;

  @Column("varchar", { name: "MemoryUsage", nullable: true, length: 50 })
  memoryUsage: string | null;

  @Column("varchar", { name: "Performance", nullable: true, length: 50 })
  performance: string | null;

  @Column("varchar", { name: "Language", nullable: true, length: 50 })
  language: string | null;
}
