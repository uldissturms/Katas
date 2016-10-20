import test from 'ava'
import checkout from './checkout'

const checkoutSingle = (t, item, price) =>
  checkoutTotalFor(t, [item], price)

const checkoutTotalFor = (t, items, total) =>
  t.is(checkout(items).total, total)

const checkoutSubTotalFor = (t, items, subTotal) =>
  t.is(checkout(items).subTotal, subTotal)

const checkoutDiscountFor = (t, items, discount) =>
  t.is(checkout(items).discount, discount)

const checkoutItemsFor = (t, items, pricedItems) =>
  t.deepEqual(checkout(items).items, pricedItems)

test('empty basket totals to 0', checkoutTotalFor, [], 0.00)

test('price single apple', checkoutSingle, 'apple', 0.25)
test('price single orange', checkoutSingle, 'orange', 0.30)
test('price single garlic', checkoutSingle, 'garlic', 0.15)
test('price single papaya', checkoutSingle, 'papaya', 0.50)

test('price multiple items',
  checkoutTotalFor, ['apple', 'apple'], 0.50)

test('no discount is applied for items that are not on offer',
  checkoutTotalFor, ['apple', 'apple', 'apple'], 0.75)

test('apply discount for items on offer', t => {
  const basket = ['papaya', 'papaya', 'papaya']
  const pricedItems = Array(3).fill({name: 'papaya', price: 0.50})
  checkoutItemsFor(t, basket, pricedItems)
  checkoutTotalFor(t, basket, 1.00)
  checkoutSubTotalFor(t, basket, 1.50)
  checkoutDiscountFor(t, basket, 0.50)
})

test('apply discount multiple times',
  checkoutTotalFor, Array(6).fill('papaya'), 2.00)
