-- Copyright (c) 2025 - Jun Dev. All rights reserved

-- Create index for full-text search
CREATE INDEX IF NOT EXISTS idx_product_searchvector 
    ON Product USING GIN (SearchVector);

CREATE INDEX IF NOT EXISTS idx_product_branch 
    ON Product(BranchId) 
 WHERE DelFlg = false;

CREATE INDEX IF NOT EXISTS idx_product_created_date 
    ON Product(DateCreated) 
 WHERE DelFlg = false;

CREATE INDEX IF NOT EXISTS idx_product_takeover 
    ON Product(TakeOverId) 
 WHERE DelFlg = false;

CREATE INDEX IF NOT EXISTS idx_product_price1 
    ON Product(Price1) 
 WHERE DelFlg = false;
