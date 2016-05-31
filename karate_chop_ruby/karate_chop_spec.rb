require_relative 'karate_chop'

RSpec.describe 'karate chop' do
  context 'returns index of a match' do
    it 'when the only item is a match' do
      result = chop(1, [1])
      expect(result).to eq 0
    end
    it 'when three items in array' do
      result = chop(3, [1, 2, 3])
      expect(result).to eq 2
    end
    it 'when four items in array' do
      result = chop(4, [1, 2, 3, 4])
      expect(result).to eq 3
    end

  end
  context 'returns -1 for no match' do
    it 'when empty' do
      result = chop(1, [])
      expect(result).to eq (-1)
    end
    it 'when single item' do
      result = chop(1, [2])
      expect(result).to eq (-1)
    end
  end
end
