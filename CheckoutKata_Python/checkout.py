catalogue = {
        'A': 50,
        'B': 30,
        'C': 20,
        'D': 15 }
discounts = {
        'A': { 'quantity': 3, 'amount': 20 },
        'B': { 'quantity': 2, 'amount': 15 }}

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
    return (count / discount['quantity']) * discount['amount']

def discount(basket):
    item_types = set(basket)
    return sum([discount_for(item_type, basket) for item_type in item_types])

def base_price(basket):
    return sum([price_for(item) for item in basket])

def total(basket):
    return base_price(basket) - discount(basket)
