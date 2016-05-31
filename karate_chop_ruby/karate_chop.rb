def chop(key, arr)
  chop_by_low_high(key, arr, 0, arr.length)
end

def chop_by_low_high(key, arr, low, high)
  return -1 if no_match_found(low, high)

  midpoint = determine_midpoint(low, high)
  candidate = arr[midpoint]
  return midpoint if candidate == key

  low, high = adjust_array(candidate, key, midpoint, low, high)
  chop_by_low_high(key, arr, low, high)
end

def no_match_found(low, high)
  low == high
end

def determine_midpoint(low, high)
  (low + high) / 2
end

def adjust_array(candidate, key, midpoint, low, high)
  if candidate > key
    [low, midpoint]
  elsif candidate < key
    [midpoint, high]
  end
end
