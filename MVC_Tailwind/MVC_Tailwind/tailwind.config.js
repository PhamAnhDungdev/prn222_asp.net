/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        // Đường dẫn tới các file sẽ sử dụng Tailwind
        "./Pages/**/*.cshtml",
        "./Views/**/*.cshtml",
        "./Components/**/*.{html,js}",
        "./wwwroot/js/**/*.js"
    ],
    theme: {
        extend: {
            // Bạn có thể mở rộng hoặc ghi đè theme mặc định ở đây
            colors: {
                // Ví dụ thêm màu tùy chỉnh
                'fu-blue': '#0066CC',
                'fu-orange': '#FF6600'
            },
            // Thêm font nếu cần
            fontFamily: {
                'sans': ['Roboto', 'sans-serif']
            }
        },
    },
    plugins: [
        // Thêm plugins nếu cần
    ],
}