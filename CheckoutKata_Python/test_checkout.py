catalogue = {
        'A': 50,
        'B': 30,
        'C': 20,
        'D': 15 }
discounts = {
        'A': { 'Quantity': 3, 'Amount': 20 },
        'B': { 'Quantity': 2, 'Amount': 15 }}

def new():
    return []

def scan(basket, item):
    return basket + [item]

def price_for(item):
    return catalogue[item]

def discount_for(item, basket):
    discount = discounts.get(item)
    if not discount:
        return 0

    count = len([1 for i in basket if i == item])
    return (count / discount['Quantity']) * discount['Amount']

def discount(basket):
    item_types = set(basket)
    return sum([discount_for(item_type, basket) for item_type in item_types])

def base_price(basket):
    return sum([price_for(item) for item in basket])

def total(basket):
    return base_price(basket) - discount(basket)

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
