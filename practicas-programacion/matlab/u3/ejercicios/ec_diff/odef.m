function dy = odef(t,y)
dy = zeros(2,1)
dy(1) = y(2)
dy(2) = (0.5).*t.*y(1)
end

