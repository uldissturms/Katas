require_relative 'bowling'

RSpec.describe 'calculate bowling score' do
  context 'for no strikes or spares' do
    it 'when gutter balls (all zero)' do
      frames = rolls([0, 0], 10)
      result = score(frames)
      expect(result).to eq 0
    end

    it 'when all threes' do
      frames = rolls([3, 3], 10)
      result = score(frames)
      expect(result).to eq 60
    end
  end

  context 'for spares' do
    it 'when all spares with first ball 3' do
      frames = rolls([3, 7], 9) + rolls([3, 7, 3])
      result = score(frames)
      expect(result).to eq 130
    end
  end

  context 'for strikes' do
    it 'when nine strikes and a gutter ball' do
      frames = rolls([10], 9) + rolls([0, 0])
      result = score(frames)
      expect(result).to eq 240
    end
    it 'when perfect game' do
      frames = rolls([10], 9) + rolls([10, 10, 10])
      result = score(frames)
      expect(result).to eq 300
    end
  end

  def rolls(frame, times=1)
    Array.new(times) { frame }
  end
end
