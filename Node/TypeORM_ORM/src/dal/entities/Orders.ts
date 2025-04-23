import {
  Column,
  Entity,
  Index,
  JoinColumn,
  ManyToOne,
  OneToMany,
  PrimaryGeneratedColumn,
} from "typeorm";
import { OrderDetails } from "./OrderDetails";
import { Customers } from "./Customers";
import { Shippers } from "./Shippers";
import { Employees } from "./Employees";

@Index("CustomerID", ["customerId"], {})
@Index("CustomersOrders", ["customerId"], {})
@Index("EmployeeID", ["employeeId"], {})
@Index("EmployeesOrders", ["employeeId"], {})
@Index("OrderDate", ["orderDate"], {})
@Index("PK_Orders", ["orderId"], { unique: true })
@Index("ShippedDate", ["shippedDate"], {})
@Index("ShippersOrders", ["shipVia"], {})
@Index("ShipPostalCode", ["shipPostalCode"], {})
@Entity("Orders", { schema: "dbo" })
export class Orders {
  @PrimaryGeneratedColumn({ type: "int", name: "OrderID" })
  orderId: number;

  @Column("nchar", { name: "CustomerID", nullable: true, length: 5 })
  customerId: string | null;

  @Column("int", { name: "EmployeeID", nullable: true })
  employeeId: number | null;

  @Column("datetime", { name: "OrderDate", nullable: true })
  orderDate: Date | null;

  @Column("datetime", { name: "RequiredDate", nullable: true })
  requiredDate: Date | null;

  @Column("datetime", { name: "ShippedDate", nullable: true })
  shippedDate: Date | null;

  @Column("int", { name: "ShipVia", nullable: true })
  shipVia: number | null;

  @Column("money", { name: "Freight", nullable: true, default: () => "(0)" })
  freight: number | null;

  @Column("nvarchar", { name: "ShipName", nullable: true, length: 40 })
  shipName: string | null;

  @Column("nvarchar", { name: "ShipAddress", nullable: true, length: 60 })
  shipAddress: string | null;

  @Column("nvarchar", { name: "ShipCity", nullable: true, length: 15 })
  shipCity: string | null;

  @Column("nvarchar", { name: "ShipRegion", nullable: true, length: 15 })
  shipRegion: string | null;

  @Column("nvarchar", { name: "ShipPostalCode", nullable: true, length: 10 })
  shipPostalCode: string | null;

  @Column("nvarchar", { name: "ShipCountry", nullable: true, length: 15 })
  shipCountry: string | null;

  @OneToMany(() => OrderDetails, (orderDetails) => orderDetails.order)
  orderDetails: OrderDetails[];

  @ManyToOne(() => Customers, (customers) => customers.orders)
  @JoinColumn([{ name: "CustomerID", referencedColumnName: "customerId" }])
  customer: Customers;

  @ManyToOne(() => Shippers, (shippers) => shippers.orders)
  @JoinColumn([{ name: "ShipVia", referencedColumnName: "shipperId" }])
  shipVia2: Shippers;

  @ManyToOne(() => Employees, (employees) => employees.orders)
  @JoinColumn([{ name: "EmployeeID", referencedColumnName: "employeeId" }])
  employee: Employees;
}
