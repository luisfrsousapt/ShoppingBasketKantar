export interface Discount {
    discountExternalId?: string;
    discountType: number;
    productId?: string;
    discountCode?: string;
    description?: string;
    value: number;
    rules?: DiscountRule[];
  }
  
  export interface DiscountRule {
    discountRuleType: number;
    productExternalId?: string;
    productQuantity?: number;
    basketTotalValue?: number;
  }