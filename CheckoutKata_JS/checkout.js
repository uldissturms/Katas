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

const price = R.flip(R.prop)(pricing)
const priceItem = R.applySpec({
  name: R.identity,
  price
})

const sumByPrice = R.pipe(
  R.prop('items'),
  R.map(R.prop('price')),
  R.sum
)
const toSummary = (value, key) => ({name: key, count: value.length})
const hasDiscount = R.pipe(R.prop('name'), R.flip(R.has)(discounts))
const discountFor = ({name, count}) =>
  Math.floor(count / discounts[name].count) * discounts[name].amount

const calculateDiscount = R.pipe(
  R.prop('items'),
  R.filter(hasDiscount),
  R.groupBy(R.prop('name')),
  R.mapObjIndexed(toSummary),
  R.map(discountFor),
  R.values,
  R.sum
)

const priceItems = R.map(priceItem)
const toBasket = items => ({items})
const subTotal = basket => R.assoc('subTotal', sumByPrice(basket))(basket)
const discount = basket => R.assoc('discount', calculateDiscount(basket))(basket)
const total = basket => R.assoc('total', basket.subTotal - basket.discount)(basket)

module.exports = R.pipe(
  priceItems,
  toBasket,
  subTotal,
  discount,
  total
)
