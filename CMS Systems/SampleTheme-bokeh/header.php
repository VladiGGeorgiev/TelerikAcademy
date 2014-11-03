<!DOCTYPE HTML>
<html>

<head>
  <title><?php bloginfo('name');?><?php wp_title();?></title>
  <meta charset="<?php bloginfo( 'charset' ); ?>" />
  <meta name="description" content="website description" />
  <meta name="keywords" content="website keywords, website keywords" />
  <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
  <link type="text/css" rel="stylesheet" href="<?php bloginfo(stylesheet_url);?>"/>
  <link rel="shortcut icon" href="<?php echo get_template_directory_uri();?>/images/icon_telerik.png" />
  <link rel="icon" href="<?php echo get_template_directory_uri();?>/images/icon_telerik.png" />
  <!-- modernizr enables HTML5 elements and feature detects -->
  <script type="text/javascript" src="<?php echo get_template_directory_uri();?>/js/modernizr-1.5.min.js"></script>
</head>

<body>
  <div id="main">
    <header>
      <div id="logo">
        <div id="logo_text">
          <!-- class="logo_colour", allows you to change the colour of the text -->
          <h1><a href="<?php echo esc_url( home_url( '/' ) ); ?>"><?php bloginfo( 'name' ); ?><span class="logo_colour">_bokeh</span></a></h1>
          <h2><?php bloginfo( 'description' ); ?></h2>
        </div>
      </div>
      <nav>
        <div id="menu_container">
			<?php wp_nav_menu(array(
				'theme_location' => 'top-menu',
				'container' => '',
				'items_wrap' => '<ul class="sf-menu" id="nav">%3$s</ul>',
			))
			?>
        </div>
      </nav>
    </header>