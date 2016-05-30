def score(frames)
  score_rolls(frames) + strike_bonuses(frames) + spare_bonuses(frames)
end

def score_rolls(frames)
  sum frames.flatten
end

# TODO: extract common bonus logic to a function and make it more functional
def strike_bonuses(frames)
  bonus = 0
  frames.each_with_index do |frame, index|
    bonus += strike_bonus(frames, index) if strike? frame
  end
  bonus
end

def spare_bonuses(frames)
  bonus = 0
  frames.each_with_index do |frame, index|
    bonus += spare_bonus(frames, index) if spare? frame
  end
  bonus
end

def sum(frame)
  frame.reduce(0, :+)
end

def strike_bonus(frames, index)
  sum ((rolls_in_frame frames[index + 1]) + (rolls_in_frame frames[index + 2]))
    .flatten
    .take(2)
end

def rolls_in_frame(frame)
  frame || []
end

def spare_bonus(frames, index)
  frames[index + 1].first
end

def spare?(frame)
  (sum frame) == 10 && !(strike? frame)
end

def strike?(frame)
  frame[0] == 10
end
