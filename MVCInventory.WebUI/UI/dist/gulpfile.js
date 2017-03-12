'use strict';
 
var gulp = require('gulp'),
    concatCss = require('gulp-concat'),
    concatFonts = require('gulp-concat'),
    concatJsFoot = require('gulp-concat'),
    concatJsHead = require('gulp-concat'),
    copy = require('gulp-copy'),
    deploy = require('vinyl-ftp'),
    flatten = require('gulp-flatten'),
    gutil = require('gulp-util'),
    newer = require('gulp-newer'),
    notify = require('gulp-notify'),
    prefix = require('gulp-autoprefixer'),
    sass = require('gulp-sass'),
    sassdoc = require('sassdoc'),
    sequence = require('run-sequence'),
    sourcemaps = require('gulp-sourcemaps'),
    uglify = require('gulp-uglify'),
    watch = require('gulp-watch');

// Compile Sass
gulp.task('sass', function () {
  return gulp
    .src('./scss/custom_app.scss')
    .pipe(sourcemaps.init())
    .pipe(sass({
        noCache: true,
        OutputStyle: "expanded",
        lineNumbers: true
    }).on('error', sass.logError))
    .pipe(prefix())
    .pipe(sourcemaps.write())
    .pipe(gulp.dest('./css'))
});

// Concatenate CSS
gulp.task('concatCss', function() {
    return gulp.src([
        './bower_components/animate-css/animate.css',
        './bower_components/footable/css/footable.core.css',
        './css/custom_app.css',
    ])
    .pipe(concatCss('style.css'))
    .pipe(gulp.dest('./css'))
});

// Concatenate Fonts
gulp.task('concatFonts', function() {
    return gulp.src([
        './fonts/ss-standard.css',
        './fonts/ss-glyphish-outlined.css'
    ])
    .pipe(concatFonts('fonts.css'))
    .pipe(gulp.dest('./fonts'))
});
    
// Concatenate <head> JavaScript
gulp.task('concatJsHead', function() {
    return gulp.src([
        'bower_components/modernizr/modernizr.js'
    ])
    .pipe(concatJsHead('head.js'))
    .pipe(gulp.dest('./js'))
});

// Concatonate foot JavaScript
gulp.task('concatJsFoot', function() {
    return gulp.src([
        'bower_components/jquery/dist/jquery.min.js',
        'bower_components/foundation/js/foundation.min.js',
        'bower_components/angular-full/angular.js',
        'bower_components/angular-full/angular-route.js',
        'bower_components/angular-elastic/elastic.js',
        'bower_components/footable/js/footable.js',
        'bower_components/footable/js/footable.filter.js',
        'bower_components/footable/js/footable.paginate.js',
        'bower_components/footable/js/footable.sort.js',
        'bower_components/angular-footable/dist/angular-footable.js',
        'bower_components/moment/moment.js',
        'bower_components/fullcalendar/dist/fullcalendar.js',
        'bower_components/headroom-js/dist/headroom.js',
        'bower_components/headroom-js/dist/jQuery.headroom.js',
        'bower_components/ng-flow/dist/ng-flow-standalone.js',
        // 'bower_components/textarea-autosize/dist/jquery.textarea_autosize.min.js',
        'js/components/_datepicker.js',
        'js/components/_double-click.js',
        'js/components/_error-message.js',
        'js/components/_file-upload.js',
        'js/components/_floating-button.js',
        'js/components/_icon-bar.js',
        //  'js/components/_input-value.js',
        'js/components/_smooth-scroll.js',
        //  'js/components/_snackbar.js',
        'js/components/_timezones.js',
        'js/custom_app.js'
    ])
    .pipe(concatJsFoot('foot.js'))
    .pipe(gulp.dest('./js'))
});

// Copy Code for Distribution
gulp.task('copy', function() {
    return gulp.src([
        './bower_components/**/*.{css,js,gif,jpeg,jpg,png,svg,webp}',
        './css/style*.css',
        './fonts/**/*',
        './icons/**/*',
        './img/**/*',
        './js/head*.js',
        './js/foot*.js',
        './*.html'
    ], {base: "."})
    .pipe(newer('./dist'))
    .pipe(gulp.dest('./dist'))
});


// Deploy Prototype via FTP
gulp.task('deploy', function() {
    var conn = deploy.create({
        host: '156.119.24.196',
        user: 'SirsUi',
        password: 'SirsR0cks',
        parallel: 10,
        log: gutil.log
    });
    var globs = [
        'dist/**/*'
    ];
    // using base = '.' will transfer everything to ./dist correctly
    // turn off buffering in gulp.src for best performance
    return gulp.src(globs,{cwd: '.', buffer: false})
    .pipe(conn.newer('./UI/dist')) // only upload newer files
    .pipe(conn.dest('./UI/dist'))
});
 
gulp.task('sass:watch', function () {
  gulp.watch('./scss/**/*.scss', ['sass']);
});

// Build UI
gulp.task('build', function(callback) {
  sequence(
      ['sass', 'concatJsHead', 'concatJsFoot'],
      'concatCss',
      'concatFonts',
      'copy',
      callback);
});

// Build and Deploy UI
gulp.task('presto', function(callback) {
  sequence('build', 'deploy', callback);
});

// Default Task
gulp.task('default', ['presto']);