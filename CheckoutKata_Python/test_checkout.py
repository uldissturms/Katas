from checkout import *

def test_price():
    yield check_price, "A", 50
    yield check_price, "B", 30
    yield check_price, "AB", 80
    yield check_price, "AAA", 130
    yield check_price, "AAAA", 180
    yield check_price, "BB", 45
    yield check_price, "C", 20
    yield check_price, "D", 15

def check_price(items, expected_price):
    assert price(items) == expected_price

def price(items):
    basket = reduce(scan, list(items), new())
    return total(basket)
