function op_args = plotting_grid(grid_size, xval, yval, varargin)
% 1. line settings
% 2. linewidth
set_lines = '-k';
set_width = 1.4;
disp(varargin);

op_args = length(varargin);
if op_args == 1
    set_lines = varargin{1};
elseif op_args == 2
    set_lines = varargin{1};
    set_width = varargin{2};
end

for c = 1:length(xval(:, 1))
    subplot(grid_size(1), grid_size(2), c);
    plot(xval(c,:), yval(c,:), set_lines, 'linewidth', set_width);
    title('titulo generico','color', [36, 36, 36]./255, 'fontsize', 14);
    ylabel('eje generico', 'fontsize', 12, 'fontangle', 'italic');
    xlabel('eje generico', 'fontsize', 12, 'fontangle', 'italic');
    grid on;
end

end

