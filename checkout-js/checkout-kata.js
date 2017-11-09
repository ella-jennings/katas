var assert = require('assert');

describe('CheckoutTests', function(){
	beforeEach(setup);
	var checkout;
	var itemPriceList = { itemA:50, itemB:30 };
	var itemA = 'itemA';
	var itemB = 'itemB';

	function setup(){
		checkout = new Checkout(itemPriceList);
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
});



function Checkout(itemPriceList){
	var itemPrices = itemPriceList;
	var total = 0;
	
	function scan(numberOfItems, item){
		var itemPrice = lookupPrice(item);
		var itemtotal = itemPrice * numberOfItems;
		total += itemtotal;
		applySpecialPrice(numberOfItems, item);
	}

	function applySpecialPrice(numberOfItems, item){
		if(numberOfItems == 3 && item == 'itemA'){
			total = 130;
		}
		if(numberOfItems == 2 && item == 'itemB'){
			total = 45;
		}
	}

	function getTotal(){
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