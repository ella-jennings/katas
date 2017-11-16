var assert = require('assert');

describe('CheckoutTests', function(){
	beforeEach(setup);
	var checkout;
	var itemPriceList = { itemA:50, itemB:30 };
	var itemA = 'itemA';
	var itemB = 'itemB';

	function setup(){
		checkout = new Checkout(itemPriceList, new DiscountCalculator());
	}

	function getExpectedCost(numberOfItems, item){
		var expectedCost = numberOfItems*itemPriceList[item];
		return expectedCost;
	}

	function checkPriceOfItems(numberScanned, expectedCost, item){
		checkout.scan(numberScanned, item);
		assert.equal(checkout.getTotal(), expectedCost);
	}

	it('Scanning one itemA costs 50', function(){
		var numberOfItems = 1;
		var expectedCost = getExpectedCost(numberOfItems, itemA);
		checkPriceOfItems(numberOfItems, expectedCost, itemA);
	})

	it('Scanning two itemA costs 100', function(){
		var numberOfItems = 2;
		var expectedCost = getExpectedCost(numberOfItems, itemA)
		checkPriceOfItems(numberOfItems, expectedCost, itemA);
	})

	it('Scanning itemB costs 30', function(){
		var numberOfItems = 1;
		var expectedCost = getExpectedCost(numberOfItems, itemB);
		checkPriceOfItems(numberOfItems, expectedCost, itemB);
	})
	it('Scanning one ItemA and one ItemB costs 80', function(){
		checkout.scan(1, itemA);
		checkout.scan(1, itemB);
		assert.equal(checkout.getTotal(), itemPriceList[itemA] + itemPriceList[itemB]);
	})
	it('Scanning three ItemA costs 130', function(){
		checkout.scan(3, itemA);
		assert.equal(checkout.getTotal(), 130);
	})
	it('Scanning two ItemB costs 45', function(){
		checkout.scan(2, itemB);
		assert.equal(checkout.getTotal(), 45);
	})

	it('Scanning three ItemA and one ItemB costs 160', function(){
		checkout.scan(3, itemA);
		checkout.scan(1, itemB);
		assert.equal(checkout.getTotal(), 160);
	})

	it('Scanning one ItemB and three ItemA costs 160', function(){
		checkout.scan(1, itemB);
		checkout.scan(3, itemA);
		assert.equal(checkout.getTotal(), 160);
	})


	it('Scanning six ItemA costs 260', function(){
		checkout.scan(6, itemA);
		assert.equal(checkout.getTotal(), 260);
	})

	it('Scanning four ItemB costs 90', function(){
		checkout.scan(4, itemB);
		assert.equal(checkout.getTotal(), 90);
	})

	it('Scanning four ItemB, one at a time costs 90', function(){
		checkout.scan(1, itemB);
		checkout.scan(1, itemB);
		checkout.scan(1, itemB);
		checkout.scan(1, itemB);
		assert.equal(checkout.getTotal(), 90);
	})
});




function Checkout(itemPriceList, discountCalculator){
	var itemPrices = itemPriceList;
	var numberOfEachItem = { itemA:0, itemB:0 };
	var total = 0;
	
	function scan(numberOfItems, item){
		var itemPrice = lookupPrice(item);
		var itemtotal = itemPrice * numberOfItems;
		total += itemtotal;
		numberOfEachItem[item] += numberOfItems;
	}

	function getTotal(){
		var discounts = discountCalculator.getTotalDiscount(numberOfEachItem);
		total = total - discounts;
		return total;
	}

	function lookupPrice(item){
		var price = itemPrices[item];
		return price;
	}
	return {
		scan: scan,
		getTotal: getTotal
	}
}

function ThirdPartyDiscountCalculator() {

	function getTotalDiscount(numberOfEachItem){
		return 20;
	}

	return {
		getTotalDiscount: getTotalDiscount
	}
}


function DiscountCalculator(){
		function getTotalDiscount(numberOfEachItem){

		var discountOne = applySpecialPrice('itemA', 3, 20, numberOfEachItem);
		var discountTwo =applySpecialPrice('itemB', 2, 15, numberOfEachItem);
		var discountTotal = discountOne + discountTwo;
		return discountTotal;
	}

	function applySpecialPrice(item, numberForDiscount, discount, numberOfEachItem){
		if((numberOfEachItem[item] % numberForDiscount) == 0){
			var numberOfDiscounts = numberOfEachItem[item] / numberForDiscount;
			discountTotal = discount*numberOfDiscounts;
			return discountTotal;
		}
		else return 0;
	}

	return {
		getTotalDiscount: getTotalDiscount
	}
}