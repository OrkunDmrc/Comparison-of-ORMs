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
import { Categories } from "./Categories";
import { Suppliers } from "./Suppliers";

@Index("CategoriesProducts", ["categoryId"], {})
@Index("CategoryID", ["categoryId"], {})
@Index("PK_Products", ["productId"], { unique: true })
@Index("ProductName", ["productName"], {})
@Index("SupplierID", ["supplierId"], {})
@Index("SuppliersProducts", ["supplierId"], {})
@Entity("Products", { schema: "dbo" })
export class Products {
  @PrimaryGeneratedColumn({ type: "int", name: "ProductID" })
  productId: number;

  @Column("nvarchar", { name: "ProductName", length: 40 })
  productName: string;

  @Column("int", { name: "SupplierID", nullable: true })
  supplierId: number | null;

  @Column("int", { name: "CategoryID", nullable: true })
  categoryId: number | null;

  @Column("nvarchar", { name: "QuantityPerUnit", nullable: true, length: 20 })
  quantityPerUnit: string | null;

  @Column("money", { name: "UnitPrice", nullable: true, default: () => "(0)" })
  unitPrice: number | null;

  @Column("smallint", {
    name: "UnitsInStock",
    nullable: true,
    default: () => "(0)",
  })
  unitsInStock: number | null;

  @Column("smallint", {
    name: "UnitsOnOrder",
    nullable: true,
    default: () => "(0)",
  })
  unitsOnOrder: number | null;

  @Column("smallint", {
    name: "ReorderLevel",
    nullable: true,
    default: () => "(0)",
  })
  reorderLevel: number | null;

  @Column("bit", { name: "Discontinued", default: () => "(0)" })
  discontinued: boolean;

  @OneToMany(() => OrderDetails, (orderDetails) => orderDetails.product)
  orderDetails: OrderDetails[];

  @ManyToOne(() => Categories, (categories) => categories.products)
  @JoinColumn([{ name: "CategoryID", referencedColumnName: "categoryId" }])
  category: Categories;

  @ManyToOne(() => Suppliers, (suppliers) => suppliers.products)
  @JoinColumn([{ name: "SupplierID", referencedColumnName: "supplierId" }])
  supplier: Suppliers;
}
