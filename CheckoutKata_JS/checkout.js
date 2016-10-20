const R = require('ramda')

const pricing = {
  apple: 0.25,
  orange: 0.30,
  garlic: 0.15,
  papaya: 0.50
}

const discounts = {
  papaya: {count: 3, amount: 0.50}
}

module.exports = items =>
  R.pipe(
    R.map(priceItem),
    toBasket,
    subTotal,
    discount,
    total)(items)

const priceItem = item => ({
  name: item,
  price: price(item)
})

const price = item => pricing[item]
const toBasket = items => ({items})

const extendBasket = fn => basket =>
  Object.assign({}, basket, fn(basket))

const subTotal = extendBasket(({items}) =>
  ({subTotal: sumByPrice(items)}))

const sumByPrice = items =>
  R.pipe(
    R.map(R.prop('price')),
    R.sum)(items)

const discount = extendBasket(({items}) =>
  ({discount: R.pipe(
    R.filter(hasDiscount),
    R.groupBy(R.prop('name')),
    R.toPairs,
    R.map(discountFor),
    R.sum
    )(items)}))

const hasDiscount = item => R.has(item.name)(discounts)
const discountFor = group =>
  Math.floor(group[1].length / discounts[group[0]].count) * discounts[group[0]].amount

const total = extendBasket(({subTotal, discount}) =>
  ({total: subTotal - discount}))

